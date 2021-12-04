
def run(input):
    part1, part2 = 0,0
    joltList = [int(jolt) for jolt in input] 
    joltList.sort()
    currentJolt = 0
    difList = [0,0,0,0]
    #this dictionary will contain the number of ways to get to a certain jolt
    combDict = {}
    #for the initial value 0, there is only one way to get there
    combDict[0] = 1
    for jolt in joltList:
        difList[jolt-currentJolt] += 1
        currentJolt = jolt
        #for each jolt, the number of ways to get there is the sum of number of ways to get to the previous 3 jolts. 
        # if the jolt does not exist, then the value is zero 
        combDict[jolt] = combDict.get(jolt-1,0) + combDict.get(jolt-2,0) + combDict.get(jolt-3,0)
    difList[3] +=1
    part1 = difList[1] * difList[3]
    part2 = combDict[joltList[-1]]

    return part1, part2
