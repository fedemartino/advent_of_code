from extract.extractdata import extract

def run():
    return solution_v2()

def solution_v2(input):
    totalCorrect = 0
    for line in input:
        datalist = line.split(' ')
        indexList = getMinMax(datalist[0])
        letter = getLetter(datalist[1])
        password = datalist[2].strip()
        letterInstances = 0
        for i in indexList:
            if (password[i-1] == letter):
                letterInstances += 1
        if (letterInstances==1):
            totalCorrect+=1
    return totalCorrect

def solution_v1(input):
    totalCorrect = 0
    for line in input:
        datalist = line.split(' ')
        min, max = getMinMax(datalist[0])
        letter = getLetter(datalist[1])
        password = datalist[2].strip()
        letterInstances = 0
        for i in range(len(password)):
            if (password[i] == letter):
                letterInstances += 1
        if (max>=letterInstances and min<=letterInstances):
            totalCorrect+=1
    return totalCorrect

def getMinMax(input):
    listData = input.split('-')
    min = listData[0]
    max = listData[1]
    return int(min),int(max)
    
def getLetter(input):
    return input[:-1].strip()
