
def run(input):
    list = getAllBoarding(input)
    maxInt = list[len(list)-1]
    missingSeat = 0
    i = 1
    while (i<len(list)-1):
        if (int(list[i])==int(list[i+1])-2):
            missingSeat = int(list[i])+1
            break
        else:
            i+=1
    return maxInt, missingSeat

def getAllBoarding(input):
    allBoarding = []
    for line in input:
        binary = line.replace("B", "1").replace("F", "0").replace("R", "1").replace("L", "0")
        intCode = int(binary, 2)
        allBoarding.append(intCode)
    allBoarding.sort()
    return allBoarding

        

