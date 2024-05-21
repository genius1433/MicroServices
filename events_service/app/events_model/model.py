from pydantic import BaseModel
from datetime import date
from typing import Optional


class Event(BaseModel):
    id: Optional[int]
    title: str
    description: str
    priority: int
    event_date: date
