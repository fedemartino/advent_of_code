import sys

def run(input, preamble):
    part1, part2 = 0,0
    for i in range(preamble, len(input)):
        targetFound = False
        targetNum = int(input[i])
        #print(targetNum)
        for firstNumIndex in range(i-preamble, i-1):
            firstNumber = int(input[firstNumIndex])
            for secondNumberIndex in range(firstNumIndex+1, i):
                secondNumber = int(input[secondNumberIndex])
                if (targetNum == firstNumber + secondNumber):
                    targetFound = True
                    break
        if (not targetFound):
            break
    part1 = targetNum
    numList = [int(val) for val in input[0:i-1]]
    #numListSum = sumList(numList) + numList[0] + numList[len(numList)-1]
    
    for x in range(len(numList)-1):
        numListSum = numList[x]
        for y in range(x+1,len(numList)):
            numListSum += numList[y]
            if (numListSum == targetNum):
                break
        if (numListSum == targetNum):
            break
    max, min = getMaxMin(numList[x:y])
    part2 = max + min
    return part1, part2
def getMaxMin(list):
    min=2147483647
    max = 0
    for x in list:
        if (x > max):
            max = x
        if (x < min):
            min = x
    return min, max
def sumList(list):
    sum = 0
    for i in list:
        sum += i
    return sum
