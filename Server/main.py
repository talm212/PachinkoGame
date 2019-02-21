from flask import Flask, jsonify, abort, make_response, request, render_template
from flask_cors import CORS, cross_origin
from flask_pymongo import PyMongo
from flask_jwt import JWT, jwt_required, current_identity
from werkzeug.security import safe_str_cmp

from machine import Machine
from machineStatistics import MachineStatistics
from user import User
from lobby import Lobby

app = Flask(__name__)
CORS(app)


users = [
    User(1, 'user1', 'abcxyz', 'bla@gmail.com'),
    User(2, 'user2', 'abcxyz', 'bla2@gmail.com')
]

username_table = {u.username: u for u in users}
userid_table = {u.user_id: u for u in users}


def authenticate(username, password):
    user = username_table.get(username, None)
    if user and safe_str_cmp(user.password.encode('utf-8'), password.encode('utf-8')):
        return user


def identity(payload):
    user_id = payload['identity']
    return userid_table.get(user_id, None)


# app.config["MONGO_URI"] = "mongodb://localhost:27017/TestDB"
# app.config['SECRET_KEY'] = 'super-secret'
# mongo = PyMongo(app)
jwt = JWT(app, authenticate, identity)


@app.route("/lobby")
def lobby():
    lobby = Lobby()
    ans = ''
    machines_list = lobby.getMachines()
    for machine_id, machine in machines_list.iteritems():
        ans += "<h1>" + str(machine.getBallsResult()) + "</h1>\n"
    return ans


@app.route("/getBallsResult/<machine_id>")
def ballsResult(machine_id):
    lobby = Lobby()
    machines_list = lobby.getMachines()
    return str(machines_list[machine_id].getBallsResult())


@app.route("/getSpinResult/<machine_id>")
def spinResult(machine_id):
    lobby = Lobby()
    machines_list = lobby.getMachines()
    return str(machines_list[machine_id].getSpinResult())


@app.route("/getBonusResult/<machine_id>")
def bonusResult(machine_id):
    lobby = Lobby()
    machines_list = lobby.getMachines()
    return str(machines_list[machine_id].getBonusResult())

@app.route("/saveResult/<hole_id>")
def saveResult(hole_id):
    return "saved"


@app.route('/protected')
@jwt_required()
def protected():
    return '%s' % current_identity


@app.route('/users/signin', methods=['POST'])
def signin():
    if 'username' in request.get_json() and \
            'password' in request.get_json() and 'passwordVerification' in request.get_json():
        username = request.get_json()['username']
        password = request.get_json()['password']
        passwordVerification = request.get_json()['passwordVerification']

    if password != passwordVerification:
        return make_response(jsonify({'error': 'password not equel password verification'}), 400)
    newUser = User(len(username_table) + 1, username, password)
    username_table[newUser.username] = newUser
    return jsonify({'id':username_table.get(username, None).id})


@app.errorhandler(404)
def not_found(error):
    return make_response(jsonify({'error': 'Not found'}), 404)


if __name__ == '__main__':
    app.run(debug=True)
