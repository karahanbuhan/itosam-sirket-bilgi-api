import requests
from bs4 import BeautifulSoup

res = requests.get("https://www.borsaningundemi.com/piyasa-ekrani/bist-hisseler")
soup = BeautifulSoup(res.content, "html.parser")

content = soup.find_all(class_="mix")

urls = []
for li in soup.find_all("li"):
    if li.get("class") is None:
        continue
    classes = li.get("class")
    for c in classes:
        if c.startswith("name_"):
            c = c.replace("name_", "")
            urls.append("https://www.borsaningundemi.com/piyasa-ekrani/hisse-detay/" + c)


print(urls)
