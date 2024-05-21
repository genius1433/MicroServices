import os
import uvicorn
from fastapi import FastAPI, Depends, HTTPException, status
from sqlalchemy.orm import Session
from typing import List, Annotated
from events_model.model import Event
from Events_database.database import EventDB, SessionLocal

app = FastAPI()


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


db_dependency = Annotated[Session, Depends(get_db)]


@app.get("/health", status_code=status.HTTP_200_OK)
async def service_alive():
    return {"message": "Service alive"}


@app.post("/add_event", response_model=Event)
async def add_event(event: Event, db: db_dependency):
    new_event = EventDB(**event.dict())
    db.add(new_event)
    db.commit()
    db.refresh(new_event)
    return new_event


@app.get("/eventss", response_model=List[Event])
async def list_events(db: db_dependency):
    return db.query(EventDB).all()


@app.get("/get_event_by_id/{event_id}", response_model=Event)
async def get_event_by_id(event_id: int, db: db_dependency):
    event = db.query(EventDB).filter(EventDB.id == event_id).first()
    if not event:
        raise HTTPException(status_code=404, detail="Event not found")
    return event


@app.delete("/delete_event/{event_id}")
async def delete_event(event_id: int, db: db_dependency):
    event = db.query(EventDB).filter(EventDB.id == event_id).first()
    if not event:
        raise HTTPException(status_code=404, detail="Event not found")
    db.delete(event)
    db.commit()
    return {"message": "Event deleted successfully"}


if __name__ == "__main__":
    uvicorn.run(app, host="0.0.0.0", port=int(os.getenv('PORT', 80)))
