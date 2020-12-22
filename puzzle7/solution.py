import re

class bag:
    def __init__(self, bagName, numberBags):
        self.bagName = bagName
        self.numberBags = numberBags
        

def run(input, bagInput):
    '''record of which bags can be stored inside the key'''
    validBagContainers = {}
    '''record of which bags can contain the key'''
    reverseValidBagContainers = {}
    for rule in input:
        '''Split rules in half with container bags and contained bags'''
        splitRule = rule.split("contain")
        leftSideOfRule = splitRule[0]
        rightSideOfRule = splitRule[1]

        '''Container bag is everything befer the word "bags" on the left side of the rule'''
        containerBag = leftSideOfRule[:leftSideOfRule.find(" bags")].strip()

        print(containerBag)

        
        print(rightSideOfRule)
        for bag in rightSideOfRule.split(","):
            shortBag = bag[:bag.find("bag")].strip()
            numberPos = re.findall("[0-9].", shortBag)
            if (len(numberPos)):
                shortBag = shortBag[len(numberPos[0])-1:].strip()
            print(shortBag)

            if (containerBag in validBagContainers.keys()):
                validBagContainers[containerBag].append(shortBag)
            else:
                validBagContainers[containerBag]= [shortBag]
            
            if (shortBag in reverseValidBagContainers.keys()):
                reverseValidBagContainers[shortBag].append(containerBag)
            else:
                reverseValidBagContainers[shortBag] = [containerBag]
    return len(reverseValidBagContainers[bagInput])