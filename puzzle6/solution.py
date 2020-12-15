#3397 too low

def run(input):
    groups = input.split("\n\n")
    anyGroupAnswer = 0
    allGroupAnswer = 0
    for group in groups:
        groupAnwers = {}
        personCount = 0
        for person in group.split("\n"):
            personCount+=1
            for answer in person:
                if (answer in groupAnwers.keys()):
                    groupAnwers[answer] = groupAnwers[answer] + 1
                else:
                    groupAnwers[answer] = 1
        for key in groupAnwers.keys():
            if (groupAnwers[key] == personCount):
                allGroupAnswer+=1
        anyGroupAnswer+=len(groupAnwers)
    return anyGroupAnswer, allGroupAnswer