import serial
from time import sleep

flag = 0

try:
    ser = serial.Serial("COM1", 9600)
except serial.serialutil.SerialException:
    try:
        ser = serial.Serial("COM2", 9600)
    except serial.serialutil.SerialException:
        try:
            ser = serial.Serial("COM3", 9600)
        except serial.serialutil.SerialException:
            try:
                ser = serial.Serial("COM4", 9600)
            except serial.serialutil.SerialException:
                try:
                    ser = serial.Serial("COM5", 9600)
                except serial.serialutil.SerialException:
                    try:
                        ser = serial.Serial("COM6", 9600)
                    except serial.serialutil.SerialException:
                        try:
                            ser = serial.Serial("COM7", 9600)
                        except serial.serialutil.SerialException:
                            print ('Microcontroller not connected')
                            flag = 1

if (flag==0):
    print("Wait for 2 seconds")
    sleep(2) # Delay for 2 seconds

    datastring = str(ser.readline()) # Read the newest output from the Arduino

    datafin = ''
    i = 0
    for i in range (2, len(datastring)-5):
        datafin += datastring[i]

    print (datafin)

    ##now need to edit the string and save it to a text file in csv format (one dataset file with all data) and one individual file with just current data
    f = open("datasetfile.txt","a")
    f.write(datafin)
    f.write('\n')
    f.close()

    fs = open("datafile.txt","w")
    fs.write(datafin)
    fs.write('\n')
    fs.close()

    print("Data collected")
