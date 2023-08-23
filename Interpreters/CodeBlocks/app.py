import os
from dotenv import load_dotenv

from DroneBlocksTelloSimulator.DroneBlocksSimulatorContextManager import DroneBlocksSimulatorContextManager

## Loaded Simulation Key required form .env file
load_dotenv()
SIM_KEY = os.getenv('SIM_KEY')

## ---------------------------------------------------------------------------------------------------------- ##
if __name__ == '__main__':

    distance = 40
    with DroneBlocksSimulatorContextManager(simulator_key=SIM_KEY) as drone:
        drone.takeoff()
        drone.fly_forward(distance, 'in')
        drone.fly_left(distance, 'in')
        drone.fly_backward(distance, 'in')
        drone.fly_right(distance, 'in')
        drone.flip_backward()
        drone.land()