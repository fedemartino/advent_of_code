
def run(seatLayout):
    part1, part2 = 0,0    
    part1 = adjacentSeat(seatLayout)
    part2 = adjacentSeat(seatLayout, 5, True)
    return part1, part2

def adjacentSeat(seatLayout, maxOccupiedSeats=4, lineOfVision=False):

    #create a row of foors
    pad = "."*(len(seatLayout[0])+2)
    #pad every seat row with a floor on each end
    seatLayout = ["."+seatRow+"." for seatRow in seatLayout]
    
    #add the row of floors at the top and bottom
    seatLayout.append(pad)
    seatLayout.insert(0, pad)

    totalOccSeats = 0
    seatMovement = True
    while(seatMovement):
        newSeatLayout = [pad]
        seatMovement = False
        for seatRow in range(1,len(seatLayout)-1):
            newSeatRow = "."
            for seatNum in range(1,len(seatLayout[seatRow])-1):
                currentSeat = seatLayout[seatRow][seatNum]
                if (currentSeat!="."):
                    occSeats = 0
                    for x in range(-1,2):
                        for y in range(-1,2):
                            if (lineOfVision and not (x==0 and y == 0)):
                                i = 1
                                xi = x
                                yi = y
                                while(seatRow-xi>=0 and seatRow-xi < len(seatLayout) and seatNum-yi>=0 and seatNum-yi< len(seatLayout[seatRow-xi])):
                                    if (seatLayout[seatRow-xi][seatNum-yi]=="#"):
                                        occSeats += 1
                                        break
                                    if (seatLayout[seatRow-xi][seatNum-yi]=="L"):
                                        break
                                    i+=1
                                    xi = x*i
                                    yi = y*i
                            else:
                                if (seatLayout[seatRow-x][seatNum-y]=="#"):
                                    occSeats += 1
                    if (currentSeat=="L" and occSeats == 0):
                        newSeatRow+="#"
                        totalOccSeats+=1
                        seatMovement = True
                    elif(currentSeat=="#" and occSeats-1 >=maxOccupiedSeats ):
                        newSeatRow+="L"
                        totalOccSeats-=1
                        seatMovement = True
                    else:
                        newSeatRow+=currentSeat
                else:
                    newSeatRow+="."
            newSeatRow+="."
            newSeatLayout.append(newSeatRow)
        newSeatLayout.append(pad)
        seatLayout = newSeatLayout
    return totalOccSeats
