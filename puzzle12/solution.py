from re import X


def run(instructions):
    currentDirection = "E"
    currentPosE = 0
    currentPosN = 0
    x = 0
    y = 0
    wayPointX = 10
    wayPointY = 1
    part1, part2 = 0,0

    
    for instr in instructions:
        direction = instr[0]
        ammount = int(instr[1:])
        if(direction == "F"):
            currentPosE, currentPosN = move(currentDirection, ammount, currentPosE, currentPosN)
            x, y = moveWaypointDirection(ammount, wayPointX, wayPointY, x, y)
        elif (direction == "R" or direction == "L"):
            currentDirection = rotateDirection(currentDirection, direction, ammount)
            wayPointX, wayPointY = rotateWaypoint(wayPointX, wayPointY, direction, ammount)
        else:
            currentPosE, currentPosN = move(direction, ammount, currentPosE, currentPosN)
            wayPointX, wayPointY = move(direction, ammount, wayPointX, wayPointY)
        #if (direction == "N"):
        #    currentPosN += ammount
        #    wayPointY += ammount
        #elif (direction == "S"):
        #    currentPosN -= ammount
        #    wayPointY -= ammount
        #elif (direction == "E"):
        #    currentPosE += ammount
        #    wayPointX += ammount
        #elif (direction == "W"):
        #    currentPosE -= ammount
        #    wayPointX -= ammount
    part1 = abs(currentPosE) + abs(currentPosN)
    part2 = abs(x) + abs(y)
    return part1, part2

def moveWaypointDirection(ammount, wayPointX, wayPointY, x, y):
    x += wayPointX * ammount
    y += wayPointY * ammount
    return x, y

def move(direction, ammount, x, y):
    if (direction == "N"):
        y += ammount
    elif (direction == "S"):
        y -= ammount
    elif (direction == "E"):
        x += ammount
    elif (direction == "W"):
        x -= ammount
    return x, y

def rotateWaypoint(wayPointX, wayPointY, direction, ammount):
    ammount = ammount % 360
    if (direction == "L" and ammount == 270):
        ammount = 90
    elif (direction == "L" and ammount == 90):
        ammount = 270
    if (ammount == 90):
        oldY = wayPointY
        wayPointY = -wayPointX
        wayPointX = oldY
    elif (ammount == 180):
        wayPointY = -wayPointY
        wayPointX = -wayPointX
    elif (ammount == 270):
        oldX = wayPointX
        wayPointX = -wayPointY
        wayPointY = oldX

    return wayPointX, wayPointY

def rotateDirection(currentDirection, rotation, ammount):
    directions = ["N", "E", "S", "W"]
    currentIndex = directions.index(currentDirection)
    rotationIndex = int(ammount / 90)
    rotationIndexDirection = 1
    if(rotation == "L"):
        rotationIndexDirection = -1
    newDir = directions[(currentIndex+rotationIndexDirection*rotationIndex)%len(directions)]
    return newDir
