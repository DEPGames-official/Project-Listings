import os
import struct

MOUSE_HID = "/dev/hidg1"

class MouseController:
    def __init__(self):
        self.fd = os.open(MOUSE_HID, os.O_RDWR | os.O_NONBLOCK)

    def send_mouse_event(self, dx, dy, btn=0):
        # HID report format: [buttons (1 byte), dx (1 byte), dy (1 byte), wheel (1 byte)]
        report = struct.pack('BbbB', btn, dx, dy, 0)
        os.write(self.fd, report)

    def move_mouse(self, dx, dy):
        self.send_mouse_event(dx, dy)

    def close(self):
        os.close(self.fd)
