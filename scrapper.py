import requests
from bs4 import BeautifulSoup

# Step 1: Get names of pages and urls

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


# Step 2: Get each page market value and book value

#for url in urls:
res = requests.get(urls[0])
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
        b = b.replace('</small><small>157.260.638,30</small></span></li>', "")
    if "Defter Değeri<" in b and "s3" in b:
        b = b.replace('<li class="s3"><p>Defter Değeri</p><span>', "")
        b = b.replace("</span></li>", "")
        print(b)

print("new Company("TÜPRAŞ - Türkiye Petrol Rafinerileri A.Ş.", new DateOnly(2015, 3, 18), 422.35, 183.55)")