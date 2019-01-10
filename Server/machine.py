class Machine:
    def __init__(self, machine_id, asset_url, machine_statistics):
        self.machine_id = machine_id
        self.asset_url = asset_url
        self.machine_statistics = machine_statistics

    def getBallsResult(self):
        return self.machine_statistics.ballStatistics()

    def getSpinResult(self):
        return self.machine_statistics.spinStatistics()

    def getBonusResult(self):
        return self.machine_statistics.bonusStatistics()

    def saveResult(self, hole):
        return True
