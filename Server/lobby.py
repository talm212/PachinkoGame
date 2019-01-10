from machine import Machine
from machineStatistics import MachineStatistics


class Lobby:
    def __init__(self):
        self.machines = {}

    def getMachines(self):
        statistics = MachineStatistics({})
        machine_id = '1'
        machine = Machine(machine_id, '/', statistics)
        self.machines[machine_id] = machine
        return self.machines
