from extract.extractdata import extract

def run(input, slopeList):
    product = 1
    for slope in slopeList:
        product = product * solution_v1(input,slope[0], slope[1])
    return product

def solution_v2():
    pass

def solution_v1(input, right, down):
    x = 0
    y = 0
    treeCount = 0
    while(y<len(input)):
        if(input[y][x]=="#"):
            treeCount += 1
        x = (x+right) % len(input[y])
        y = y + down
    return treeCount
