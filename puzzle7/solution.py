import re

class Bag:
    def __init__(self, bagName):
        self.bagName = bagName
        self.bagList = {}

    def add(self, bag, bagNumber):
        self.bagList[bag.bagName] = bag, bagNumber

    def find(self, bagNameToFind):
        #print("Looking inside the " + self.bagName + " bag")
        result = False
        for bagName in self.bagList.keys():
            bagInList, bagQty = self.bagList[bagName]
            if (bagInList.bagName == bagNameToFind): 
                result = True
            result = result or bagInList.find(bagNameToFind)
        return result
            

def run(input, bagInput):
    allBags, mainBags = buildTree(input)
    containedIn = 0
    for bagName, bag in mainBags.items():
        if (bag.find(bagInput)):
            containedIn += 1
    return containedIn, 0

def buildTree(input):
    allBags = {}
    mainBags = {}

    for rule in input:
        '''Split rules in half with container bags and contained bags'''
        splitRule = rule.split("contain")
        leftSideOfRule = splitRule[0]
        rightSideOfRule = splitRule[1]

        '''Container bag is everything befer the word "bags" on the left side of the rule'''
        mainBagName = leftSideOfRule[:leftSideOfRule.find(" bags")].strip()
        if (mainBagName in allBags.keys()):
            containerBag = allBags[mainBagName]
        else:
            containerBag = Bag(mainBagName)
            allBags[mainBagName] = containerBag
        
        if (mainBagName not in mainBags.keys()):
            mainBags[mainBagName] = containerBag

        for bag in rightSideOfRule.split(","):
            shortBag = bag[:bag.find("bag")].strip()
            numberPos = re.findall("[0-9].", shortBag)
            nodeNumber = 0
            if (len(numberPos)):
                shortBag = shortBag[len(numberPos[0])-1:].strip()
                nodeNumber = int(numberPos[0].strip())
            if (shortBag in allBags.keys()):
                containedBag = allBags[shortBag]
            else:
                containedBag = Bag(shortBag)
                allBags[shortBag] = containedBag
            containerBag.add(containedBag, nodeNumber)

    return allBags, mainBags