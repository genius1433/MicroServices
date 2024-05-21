from sqlalchemy import create_engine, Column, Integer, String, Text, Date
from sqlalchemy.orm import sessionmaker, declarative_base

URL = 'postgresql://secUREusER:StrongEnoughPassword)@51.250.26.59:5432/query'

engine = create_engine(URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)
Base = declarative_base()


class EventDB(Base):
    __tablename__ = 'events_Marinov'

    id = Column(Integer, primary_key=True, index=True)
    title = Column(String, nullable=False)
    description = Column(Text, nullable=False)
    priority = Column(Integer, nullable=False)
    event_date = Column(Date, nullable=False)


Base.metadata.create_all(bind=engine)
