import re

class Bag:
    def __init__(self, bagName):
        self.bagName = bagName
        self.bagList = {}

    def add(self, bag, bagNumber):
        self.bagList[bag.bagName] = bag, bagNumber

    def find(self, bagNameToFind):
        
        result = False
        quantity = 1
        for bagName in self.bagList.keys():
            bagInList, bagQty = self.bagList[bagName]
            if (bagInList.bagName == bagNameToFind): 
                result = True
            intermediateResult, qty = bagInList.find(bagNameToFind)
            result = result or intermediateResult
            quantity = quantity + qty*bagQty
        return result, quantity
            

def run(input, bagInput):
    allBags, mainBags = buildTree(input)
    containedIn = 0
    qtyResult = 0
    for bagName, bag in mainBags.items():
        result, qty = bag.find(bagInput)
        if (result):
            containedIn += 1
        if (bagName == bagInput):
            qtyResult = qty
    return containedIn, qtyResult-1

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