import math
import serial
import struct
from mouse_control import MouseController

STC = 0x02  # Start byte for coordinates
ETC = 0x03  # End byte for coordinates

def process_data(buf, total_bytes, mouse):
    if buf[0] == STC:
        if len(buf) == total_bytes and buf[-1] == ETC:
            try:
                half_length = len(buf) // 2
                # Unpack X and Y coordinates from the buffer
                x_raw = struct.unpack('<d', buf[1:half_length])[0]
                y_raw = struct.unpack('<d', buf[half_length:-1])[0]
                
                # Debug output for raw buffer and values
                #print("Buffer slices:", buf[1:half_length], buf[half_length:-1])
                #print("Raw unpacked values:", x_raw, y_raw)
                
                # Check if values are NaN before converting
                if math.isnan(x_raw) or math.isnan(y_raw):
                    print("Error: NaN values received.")
                    return
                
                # Convert to integer
                x = int(x_raw)
                y = int(y_raw)
                
                mouse.move_mouse(x, y)
                
                #print(f"Received coordinates: X = {x}, Y = {y}")
                
            except struct.error as e:
                print(f"Error unpacking data: {e}")
                return
        else:
            print("Invalid data length or end byte. Skipping packet.")
            return
    else:
        print("Unknown start byte. Skipping packet.")
        return

def read_data(port, mouse):
    buf = bytearray()
    total_bytes = 18  # STC (1 byte) + X (8 bytes) + Y (8 bytes) + ETC (1 byte)
    
    while True:
        read_buf = port.read(1)  # Read one byte at a time
        if not read_buf:
            continue

        # Append new data to buffer
        buf.extend(read_buf)

        if buf[0] == STC:
            # Found the start byte, now read until the end byte
            while True:
                read_buf = port.read(1)  # Read one byte at a time
                if not read_buf:
                    continue
                
                buf.extend(read_buf)
                
                if buf[-1] == ETC:
                    # Found the end byte, process the data
                    process_data(buf, total_bytes, mouse)
                    buf = bytearray()  # Clear the buffer for the next packet
                    break  # Exit the inner loop and continue reading
        else:
            buf.pop(0)  # Remove incorrect leading bytes

def main():
    port_name = "/dev/serial0"
    try:
        port = serial.Serial(port_name, baudrate=115200, bytesize=8, parity=serial.PARITY_NONE, stopbits=serial.STOPBITS_ONE)
        # Create an instance of MouseController 
        mouse = MouseController()
        print("Reading data from serial port...")
        read_data(port, mouse)
    except serial.SerialException as e:
        print(f"Error opening port: {e}")

if __name__ == "__main__":
    main()

