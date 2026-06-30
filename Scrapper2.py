import requests
from bs4 import BeautifulSoup
import time
from time import sleep
import sys

# Step 1: Get names of pages and urls

res = requests.get("https://www.borsaningundemi.com/piyasa-ekrani/bist-hisseler")
soup = BeautifulSoup(res.content, "html.parser")

content = soup.find_all(class_="mix")

companies = []
urls = []
for li in soup.find_all("li"):
    if li.get("class") is None:
        continue
    classes = li.get("class")
    for c in classes:
        if c.startswith("name_"):
            c = c.replace("name_", "")
            urls.append("https://www.borsaningundemi.com/piyasa-ekrani/hisse-detay/" + c)
            companies.append(c)


# Step 2: Get each page market value and book value
mvalues = [0] * 5000
bvalues = [0] * 5000

#for url in urls:
for j in range(172, 2000):
    res = requests.get(urls[j], allow_redirects=False)
    soup = BeautifulSoup(res.content, "html.parser")

    buff = []
    a = soup.find_all("li")
    for q in a:
        if q.get("class") is None:
            continue
        buff.append(q)

    for b in buff:
        b = str(b)
        if "c7" in b:
            b = b.replace('<li class="c7"><p>Piyasa Değeri</p><span><b>TL</b><b>USD</b><small>', "")
            b = b.split("</small>")[0]
            mvalues[j] = b
        if "Defter Değeri<" in b and "s3" in b:
            b = b.replace('<li class="s3"><p>Defter Değeri</p><span>', "")
            b = b.replace("</span></li>", "")
            bvalues[j] = b

    time.sleep(0.5)
    print("new Company(\"{0}\", {1}, {2}),".format(companies[j], str(mvalues[j]).replace(".", "").replace(",00", ""), str(bvalues[j]).replace(",", ".")))