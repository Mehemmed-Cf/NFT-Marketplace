const NFT_Cards_Section = document.querySelector(".NFT-Cards_Section");
const loaderElement = document.querySelector(".Loader");
const LoaderIcon = document.querySelector(".LoaderIcon");
const SeeMore_Btn = document.querySelector(".SeeMore-Btn");
const NoMore_Message = document.querySelector(".NoMore");
const Search_Input = document.querySelector(".Search-Input");
let skipCount = 0;

getDataForNFTs();

async function getDataForNFTs() {
  showLoader(true);

  const response = await fetch("http://localhost:3000/api/nfts", {
    method: "POST",
    headers: {
      "CONTENT-TYPE": "application/json",
    },
    body: JSON.stringify({
      pageSize: 6,
    }),
  });

  data = await response.json();

  fillNFTMarketplace(data);

  showLoader(false);
}

function fillNFTMarketplace(data) {
  data.nfts.forEach((nft) => {
    const NFT_Card = document.createElement("div");
    NFT_Card.className = "NFT-Card";

    const Image = document.createElement("div");
    Image.className = "Image";

    const ImageElement = document.createElement("img");
    ImageElement.src = "~/Frontend/../" + nft.imgPath;
    Image.append(ImageElement);

    const NFT_Info = document.createElement("div");
    NFT_Info.className = "NFT-Info ";

    const Artist_Info = document.createElement("div");
    Artist_Info.className = "Artist-Info";

    const NFT_Name = document.createElement("h1");
    NFT_Name.textContent = nft.name;

    const Artist_Avatar_And_Name = document.createElement("div");
    Artist_Avatar_And_Name.className = "Artist-AvatarAndName";

    const Artist_Avatar = document.createElement("div");
    Artist_Avatar.className = "Avatar";

    const Avatar_Image = document.createElement("img");
    Avatar_Image.src = "~/Frontend/../" + nft.creator.profileImgPath;

    Artist_Avatar.append(Avatar_Image);

    const Artist_Name = document.createElement("h1");
    Artist_Name.textContent = nft.creator.name;

    Artist_Avatar_And_Name.append(Artist_Avatar, Artist_Name);

    Artist_Info.append(NFT_Name, Artist_Avatar_And_Name);

    const Additional_Info = document.createElement("div");
    Additional_Info.className = "Additional-Info";

    const Price = document.createElement("div");
    Price.className = "Price";

    const Price_Key = document.createElement("h1");
    Price_Key.textContent = "Price";

    const Price_Value = document.createElement("p");
    Price_Value.textContent = nft.price.value + "" + nft.price.currency;

    Price.append(Price_Key, Price_Value);

    const HighestBid = document.createElement("div");
    HighestBid.className = "Highest-Bid";

    const Bid_Key = document.createElement("h1");
    Bid_Key.textContent = "Highest Bid";

    const Bid_Value = document.createElement("p");
    Bid_Value.textContent = nft.highestBid.value + "" + nft.highestBid.currency;

    HighestBid.append(Bid_Key, Bid_Value);

    Additional_Info.append(Price, HighestBid);

    NFT_Info.append(Artist_Info, Additional_Info);

    NFT_Card.append(Image, NFT_Info);

    NFT_Cards_Section.append(NFT_Card);
  });
}

async function Search(search) {
  showLoader(true);

  const response = await fetch("http://localhost:3000/api/nfts", {
    method: "POST",
    headers: {
      "CONTENT-TYPE": "application/json",
    },
    body: JSON.stringify({
      pageSize: 3,
      searchStr: search,
    }),
  });

  const SearchData = await response.json();

  if (SearchData.nfts.length == 0) {
    NoMore_Message.style.display = "initial";
    NoMore_Message.textContent = "No NFTs ;(";
  }

  if (response.hasMore == true) {
    NoMore_Message.style.display = "none";
    SeeMore_Btn.style.display = "initial";
  } else {
    SeeMore_Btn.style.display = "none";
  }

  emptyMarketplace();

  fillNFTMarketplace(SearchData);

  showLoader(false);
}

Search_Input.addEventListener("keypress", () => {
  const search = Search_Input.value.trim();

  if (search == "") return;

  Search(search);
});

SeeMore_Btn.addEventListener("click", () => {
  if (data.hasMore == true) {
    showLoader(true);

    fetch("http://localhost:3000/api/nfts", {
      method: "POST",
      headers: {
        "CONTENT-TYPE": "application/json",
      },
      body: JSON.stringify({
        skip: (skipCount += 6),
        pageSize: 6,
      }),
    })
      .then((newRes) => newRes.json())
      .then((newData) => {
        if (newData.hasMore == false) {
          SeeMore_Btn.style.display = "none";
          NoMore_Message.style.display = "initial";
        }
        fillNFTMarketplace(newData);
      });

    showLoader(false);
  }
});

function emptyMarketplace() {
  while (NFT_Cards_Section.firstChild) {
    NFT_Cards_Section.removeChild(NFT_Cards_Section.firstChild);
  }
}

function showLoader(show) {
  loaderElement.style.display = show ? "grid" : "none";
}
