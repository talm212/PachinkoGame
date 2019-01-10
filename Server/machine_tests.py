import pytest
from lobby import Lobby
from machine import Machine
from machineStatistics import MachineStatistics


@pytest.fixture
def lobby():
    return Lobby()


@pytest.fixture
def machines(lobby):
    return lobby.getMachines()


@pytest.fixture
def machine(machines):
    return machines['1']


def test_machines_size(machines):
    assert len(machines) == 1


def test_machines_type(machine):
    assert isinstance(machine, Machine)


def test_getBallsResult(machine):
    assert machine.getBallsResult()



# def test_setting_initial_amount(wallet):
#     assert wallet.balance == 20
#
#
# def test_wallet_add_cash(wallet):
#     wallet.add_cash(80)
#     assert wallet.balance == 100
#
#
# def test_wallet_spend_cash(wallet):
#     wallet.spend_cash(10)
#     assert wallet.balance == 10
#
#
# def test_wallet_spend_cash_raises_exception_on_insufficient_amount(empty_wallet):
#     with pytest.raises(InsufficientAmount):
#         empty_wallet.spend_cash(100)
