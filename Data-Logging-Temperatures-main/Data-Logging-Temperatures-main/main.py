global middayTemp
global midnightTemp

middayTemps = [23,32,12,34,23,43,23,43,23.3,12.3,43.5,23,32,12,34,23,43,23,43,23.3,12.3,43.5,23,32,12,34,23,43,23,43]
midnightTemps = [12.3,11.4,2,8,9,10,12,23,9.5,-13.6,11,12.3,11.4,2,8,9,10,12,23,9.5,-12.6,11,12.3,11.4,2,8,9,10,12,23]

minimumTemperature = -60
maximumTemperature = 60


def main():
    request()
    getAverageTemperatures()
    getTemperatureInfo()

def request():
    print("Would you like to add temps for today?")
    print("Type \"Y\" for yes or \"N\" for no")
    answer = input().strip().upper()
    try:
        if answer == "Y":
            addMiddayTemp()
            addMidnightTemp()
            print("Temperatures added!")
            request()

        elif answer == "N":
            print("SAD NOISESSSSS!!!")

        else:
            raise ValueError

    except ValueError:
        print("Invalid input, please make sure you are inputting \"Y\" for yes or \"N\" for no only")
        request()


def addMiddayTemp():
    print("What is the Midday Temperature for today?: ")
    try:
        middayTemp = float(input())
        if middayTemp < minimumTemperature or middayTemp > maximumTemperature:
            raise ValueError

        middayTemps.append(middayTemp)
    except:
        print(f"Invalid input, please make sure you are inputting a number between {minimumTemperature}°C and {maximumTemperature}°C")
        addMiddayTemp()



def addMidnightTemp():
    print("What is the Midnight Temperature for today?: ")
    try:
        midnightTemp = float(input())
        if midnightTemp < minimumTemperature or midnightTemp > maximumTemperature:
            raise ValueError
        midnightTemps.append(midnightTemp)
    except:
        print(f"Invalid input, please make sure you are inputting a number between {minimumTemperature}°C and {maximumTemperature}°C")
        addMidnightTemp()

def averageTemperature(Temperaturelist):
    totalTemperature = 0

    for temperature in Temperaturelist:
        totalTemperature += temperature

    average = totalTemperature / len(Temperaturelist)
    average = round(average, 1)
    return float(average)

def getAverageTemperatures():
    averageMidday = averageTemperature(middayTemps)
    averageMidnight = averageTemperature(midnightTemps)

    print(f"The average temperature for Midday for the month is {averageMidday}°C")
    print(f"The average temperature for Midnight for the month is {averageMidnight}°C")

#Get highest midday temperature and minimum midnight temperature and output the dates of each with a suitable message
def getTemperatureInfo():
    maxMiddayTemperature = max(middayTemps)
    minMidnightTemperature = min(midnightTemps)

    maxMiddayTemperatureDate = middayTemps.index(maxMiddayTemperature) + 1
    minMidnightTemperatureDate = midnightTemps.index(minMidnightTemperature) + 1

    print(f"The highest midday temperature occured on day {maxMiddayTemperatureDate} at a temperature of {maxMiddayTemperature}°C this month")
    print(f"The lowest midnight temperature occured on day {minMidnightTemperatureDate} at a temperature of {minMidnightTemperature}°C this month")

main()