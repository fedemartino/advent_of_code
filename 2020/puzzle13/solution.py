def run(timetable):
    part1, part2 = 0,0
    earliestLeave = int(timetable[0])
    busIds = [int(x) for x in timetable[1].split(",") if x != "x"]
    bestBus = earliestLeave
    minWaitTime = earliestLeave
    
    for busId in busIds:
        waitTime = - (earliestLeave % busId) + busId
        if(waitTime<minWaitTime):
            bestBus = busId
            minWaitTime = waitTime
    part1 = bestBus * minWaitTime
    
    busses = [(i, int(bus)) for i, bus in enumerate(timetable[1].split(",")) if bus != "x"]
    
    minTimeStamp = 0
    busProduct = 1

    for (offset, busId) in busses:
        while True:
            minTimeStamp += busProduct
            if (minTimeStamp + offset) % busId == 0:
                busProduct =  busProduct * busId
                break
    part2 = minTimeStamp
    
    return part1, part2