##255<answer<264
import re

class passport:
    def __init__(self):
        self.fields = {}
    def isValid():
        return True;

def run(input, mandatoryFields):
    validPassportCount = 0
    for line in input.split("\n\n"):
        validPass = isValidPassport(line, mandatoryFields)
        if (validPass):
            validPassportCount+=1
    return validPassportCount

def isValidPassport(passport, mandatoryFields):
    isValid = True
    for field in mandatoryFields:
        isValid = isValid and passport.find(field)!=-1
    return isValid
