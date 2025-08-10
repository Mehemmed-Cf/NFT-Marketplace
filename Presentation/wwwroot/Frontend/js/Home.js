const Rankings = document.querySelector("#Rankings");
const ConnectAWallet = document.querySelector("#ConnectAWallet");
const loaderElement = document.querySelector(".Loader");

const GetStarted_Btn = document.querySelector(".GetStarted-Btn");
GetStarted_Btn.addEventListener("click", () => {
    window.open("https://localhost:7145/CreateAccount", "_self");
});

const HomeNFT = document.querySelector(".HighlightedNFT-Img");
HomeNFT.addEventListener("click", () => {
    window.open("Marketplace", "_self");
});

const CollectionCards = document.querySelectorAll(".CollectionCard");
CollectionCards.forEach((CollectionCard) => {
    CollectionCard.addEventListener("click", () => {
        window.open("https://localhost:7145/Marketplace", "_self");
    });
});

const ViewRankings_Btn = document.querySelector(".ViewRankings-Btn");
ViewRankings_Btn.addEventListener("click", () => {
    window.open("Rankings", "_self");
});

const SeeAll_Btn = document.querySelector(".SeeAll-Btn");
SeeAll_Btn.addEventListener("click", () => {
    window.open("../Marketplace/index.html", "_self");
});

const NFTCards = document.querySelectorAll(".NFTCard");
NFTCards.forEach((NFTCard) => {
    NFTCard.addEventListener("click", () => {
        window.open("https://localhost:7145/Marketplace", "_self");
    });
});

const SeeNFT_Btn = document.querySelector(".SeeNFT-Btn");
SeeNFT_Btn.addEventListener("click", () => {
    window.open("https://localhost:7145/Marketplace", "_self");
});

function getDataFromServer() {
    showLoader(true);

    fetch("/Home/GetCreators")
        .then(res => {
            if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
            return res.json();
        })
        .then(data => {
            fillArtistContainer(data);
            showLoader(false);
        })
        .catch(error => {
            console.error('Fetch error:', error);
            showLoader(false);
        });
}

function fillArtistContainer(data) {
    if (!data) return;

    data.forEach((creator, index) => addCreator(creator, index));
}

function addCreator(data, index) {
    const Artist_Cards = document.querySelector(".Artist-Cards");

    const ArtistCard = document.createElement("div");
    ArtistCard.classList.add("Artist-Card");

    const Artist_Avatar = document.createElement("div");
    Artist_Avatar.className = "Artist-Avatar";

    const Artist_Info = document.createElement("div");
    Artist_Info.className = "Artist-Info";

    const Artist_Ranking = document.createElement("div");
    Artist_Ranking.className = "Ranking-Number";

    const AvatarIcon = document.createElement("img");
    AvatarIcon.src = data.imagePath;
    Artist_Avatar.append(AvatarIcon);

    const CreatorName = document.createElement("h1");
    CreatorName.textContent = data.nickName;

    const Sales_Info = document.createElement("div");
    Sales_Info.className = "Sales-Info";
    const Sales_Info_Key = document.createElement("p");
    Sales_Info_Key.className = "Sales-Info_Key";
    Sales_Info_Key.textContent = "Total Sales:";
    const Sales_Info_Value = document.createElement("p");
    Sales_Info_Value.className = "Sales-Info_Value";
    Sales_Info_Value.textContent = `${data.totalSales} ETH`;
    Sales_Info.append(Sales_Info_Key, Sales_Info_Value);

    Artist_Info.append(CreatorName, Sales_Info);

    if (index + 1 > 9) {
        const RankingNumber = document.createElement("p");
        RankingNumber.textContent = index + 1;
        RankingNumber.className = "position-left-change";
        Artist_Ranking.append(RankingNumber);
    } else {
        const RankingNumber = document.createElement("p");
        RankingNumber.textContent = index + 1;
        Artist_Ranking.append(RankingNumber);
    }

    ArtistCard.append(Artist_Avatar, Artist_Info, Artist_Ranking);
    Artist_Cards.append(ArtistCard);

    ArtistCard.addEventListener("click", () => {
        window.open(`../Artist_Detail?id=${data.id}`, "_self");
    });
}

function showLoader(show) {
    loaderElement.style.display = show ? "grid" : "none";
}

document.addEventListener("DOMContentLoaded", () => {

    const Marketplace_Link = document.querySelector("#MarketPlaceLink");
    const SignUpBtn = document.querySelector(".SignUp-Btn");

    Marketplace_Link.addEventListener("click", () => {
        window.open("https://localhost:7145/Marketplace", "_self");
    });

    SignUpBtn.addEventListener("click", () => {
        window.open("https://localhost:7145/CreateAccount", "_self");
    });

});

window.addEventListener("DOMContentLoaded", getDataFromServer);