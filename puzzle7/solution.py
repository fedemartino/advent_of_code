import re

class Bag:
    def __init__(self, bagName):
        self.bagName = bagName
        self.bagList = {}
    def __str__(self) -> str:
        return self.bagName + " -> " + str(self.bagList)

    def add(self, bag, bagNumber):
        self.bagList[bag.bagName] = BagNode(bag, bagNumber)

class BagNode:
    def __init__(self, bag, numberBags):
        self.bag = bag
        self.numberBags = numberBags
    def __str__(self) -> str:
        return str(self.numberBags) +" : "+  str(self.bag.bagName)
    

def run(input, bagInput):
    allBags = buildTree(input)
    for bag in allBags.keys():
        #pass
        print(allBags[bag])
    return len(allBags)

def buildTree(input):
    allBags = {}

    #'''record of which bags can be stored inside the key'''
    #validBagContainers = {}
    #'''record of which bags can contain the key'''
    #reverseValidBagContainers = {}
    
    for rule in input:
        '''Split rules in half with container bags and contained bags'''
        splitRule = rule.split("contain")
        leftSideOfRule = splitRule[0]
        rightSideOfRule = splitRule[1]

        '''Container bag is everything befer the word "bags" on the left side of the rule'''
        containerBag = Bag(leftSideOfRule[:leftSideOfRule.find(" bags")].strip())
        allBags[containerBag.bagName] = containerBag

        #print("Container Bag -> "+  str(containerBag))
        #print(rightSideOfRule)

        for bag in rightSideOfRule.split(","):
            shortBag = bag[:bag.find("bag")].strip()
            numberPos = re.findall("[0-9].", shortBag)
            nodeNumber = 0
            if (len(numberPos)):
                shortBag = shortBag[len(numberPos[0])-1:].strip()
                nodeNumber = int(numberPos[0].strip())
            
            containedBag = Bag(shortBag)
            containerBag.add(containedBag, nodeNumber)
            #print(bag)
            #print("Contained Bag -> " + str(containedBag) + " " + str(nodeNumber))
    return allBags