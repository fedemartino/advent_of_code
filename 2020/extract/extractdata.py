def extract(path):
    file = open(path, "r")
    content = file.readlines()
    content = [x.strip() for x in content]
    file.close()
    return content
def extractRaw(path):
    file = open(path, "r")
    content = file.read()
    file.close()
    return content