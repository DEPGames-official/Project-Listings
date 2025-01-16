from evdev import UInput, ecodes
import time

# Define the capabilities of the virtual keyboard
capabilities = {
    ecodes.EV_KEY: (ecodes.KEY_A, ecodes.KEY_B, ecodes.KEY_C)  # Define some keys
}

# Create the virtual keyboard device
with UInput(capabilities, name="Virtual Keyboard") as virtual_keyboard:
    print("Virtual Keyboard created. Typing 'ABC'...")

    # Type 'A'
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_A, 1)  # Key down
    virtual_keyboard.syn()
    time.sleep(0.1)
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_A, 0)  # Key up
    virtual_keyboard.syn()
    
    # Type 'B'
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_B, 1)  # Key down
    virtual_keyboard.syn()
    time.sleep(0.1)
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_B, 0)  # Key up
    virtual_keyboard.syn()
    
    # Type 'C'
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_C, 1)  # Key down
    virtual_keyboard.syn()
    time.sleep(0.1)
    virtual_keyboard.write(ecodes.EV_KEY, ecodes.KEY_C, 0)  # Key up
    virtual_keyboard.syn()

    print("Typed 'ABC'")
