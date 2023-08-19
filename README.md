# Final_Year_Project_Group3


# Setting up your dev enviroment

    Ensure your Git project is up to date.
        - Open VScode integrated terminal 
            -type "git pull origin"

    Install python3. 
        - If you are not comfortable using the command line and have a windows machine, Search Python in the Microsoft Store
        - Confirm whether python is installed by typing in "python3 --version" in a terminal
            - You might be required to restart your operating system.

    Install the python exstention to VSCode

    Open the integrated terminal in VSCode
        - Set up your python virtual enviroment in windows
            Open your integrated terminal in the root directory of the project:
            - Type "python3 -m venv venv"
                on some systems it might be "python -m venv venv"
            - Type ".\venv\Scripts\activate"
                windows might be blocking running scripts, if that is the case:
                    - Open windows powershell as Administrator
                        - Type "set-executionpolicy remotesigned"
                        - Type "Y" and hit Enter
                    - Retry ".\venv\Scripts\activate" in the VSCode terminal

    Now Install DroneBlocksTelloSimulator
        - Type "pip install DroneBlocksTelloSimulator" in the integrated terminal
        - Open "http://coding-sim.droneblocks.io/"

            You might need to configure Chrome to "Allow Insecure Content" for the simulator.
            This is not a security risk and will only be done for this domain.
            This will allow the DroneBlocks simulator to receive commands from Python.
            Follow these steps:
                1. Click on the lock icon next to the web address
                2. Click on "Site settings"
                3. Scroll to the bottom and look for "Insecure content"
                4. Change "Block" to "Allow"
                5. Close the tab and refresh the simulator

            You can now move onto programming the simulated drone mission in Python!
            Click the button in the top left of the DroneBlocks simulator that says "Get Drone Simulator Key".
            Copy this unique key to your clipboard as it will be used in your mission code.

# flying a drone

drone.fly=true

# landing a drone 
drone.land= s
# charing the drone

solar=true
battey=true
gastank=full
windturbine=flase
#Camera
 cam1=on
 cam2=on
 cam3=on
 cam4=on
 cam5= raidor
 cam6= temprituregun
 #some Mlg fituters 
 diliver=true
 diliver=false
 gprs=5g
 controlls = true 


