from group import GroupListResource, GroupResource
from event import EventListResource, EventResource
from attendee import AttendeeListResource, AttendeeResource
from flask import Flask
from flask_restful import Api
from flask_cors import CORS



app = Flask(__name__)
CORS(app)
api = Api(app)



##
## Actually setup the Api resource routing here
##
api.add_resource(AttendeeListResource, '/attendees')
api.add_resource(AttendeeResource, '/attendees/<attendee_id>')
api.add_resource(EventListResource, '/events')
api.add_resource(EventResource, '/events/<event_id>')
api.add_resource(GroupListResource, "/groups")
api.add_resource(GroupResource, "/groups/<group_id>")



if __name__ == '__main__':
    app.run(debug=True)
        
