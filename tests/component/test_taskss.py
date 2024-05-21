import requests
from datetime import date

base_url = 'http://localhost:8000'
add_event_url = f'{base_url}/add_event'
get_events_url = f'{base_url}/eventss'
get_event_by_id_url = f'{base_url}/get_event_by_id'
delete_event_url = f'{base_url}/delete_event'

new_event = {
    "id": 99,
    "title": "Complete Assignment",
    "description": "Finish the mathematics assignment",
    "priority": 1,
    "due_date": str(date(2024, 6, 1))
}

def test_health_check():
    response = requests.get(f"{base_url}/health")
    assert response.status_code == 200
    assert response.json() == {"message": "Service alive"}

def test_add_event():
    response = requests.post(add_event_url, json=new_event)
    assert response.status_code == 200
    assert response.json()['title'] == new_event['title']

def test_get_events():
    response = requests.get(get_events_url)
    assert response.status_code == 200
    assert len(response.json()) > 0

def test_get_event_by_id():
    response = requests.get(f"{get_event_by_id_url}/99")
    assert response.status_code == 200
    assert response.json()['title'] == new_event['title']

def test_delete_event():
    delete_response = requests.delete(f"{delete_event_url}/99")
    assert delete_response.status_code == 200
    response = requests.get(f"{get_event_by_id_url}/99")
    assert response.status_code == 404

