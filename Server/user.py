class User(object):
    def __init__(self, user_id, username, password, email):
        self.user_id = user_id
        self.username = username
        self.password = password
        self.email = email
        self.collections = {'balls': 0}

    def __str__(self):
        return "User(id='%s')" % self.user_id
