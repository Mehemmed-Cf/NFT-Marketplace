const Rankings = document.querySelector("#Rankings");
const ConnectAWallet = document.querySelector("#ConnectAWallet");
const loaderElement = document.querySelector(".Loader");

const GetStarted_Btn = document.querySelector(".GetStarted-Btn");
GetStarted_Btn.addEventListener("click", () => {
    window.open("https://localhost:7145/CreateAccount", "_self");
});

const HighlightedNFT = document.querySelector(".HighlightedNFT");
HighlightedNFT.addEventListener("click", () => {
    window.open(`../Nft_Detail?id=7`, "_self");
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
    window.open("https://localhost:7145/Marketplace", "_self");
});

//const NFTCards = document.querySelectorAll(".NFTCard");
//NFTCards.forEach((NFTCard) => {
//    NFTCard.addEventListener("click", () => {
//        window.open("https://localhost:7145/Marketplace", "_self");
//    });
//});

const SeeNFT_Btn = document.querySelector(".SeeNFT-Btn");
SeeNFT_Btn.addEventListener("click", () => {
    window.open("https://localhost:7145/Marketplace", "_self");
});

function getDataForNfts() {
    showLoader(true);

    fetch("/Home/GetRandomNfts")
        .then(res => {
            if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
            return res.json();
        })
        .then(data => {
            console.log(data);
            fillRandomNfts(data);
            showLoader(false);
        })
        .catch(error => {
            console.error('Fetch error:', error);
            showLoader(false);
        });
}

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

function fillRandomNfts(data) {
    const NFTCards_Row = document.querySelector(".NFTCards-Row");

    data.nfts.forEach((nft) => {

        console.log(nft);

        const NFT_Card = document.createElement("div");
        NFT_Card.className = "NFTCard";

        const Image = document.createElement("div");
        Image.className = "Image";

        const ImageElement = document.createElement("img");
        ImageElement.src = nft.imagePath;
        Image.append(ImageElement);

        const NFT_Info = document.createElement("div");
        NFT_Info.className = "NFT-Info ";

        const Artist_Info = document.createElement("div");
        Artist_Info.className = "Artist-Info";

        const NFT_Name = document.createElement("h1");
        NFT_Name.textContent = nft.title;

        const Artist_Avatar_And_Name = document.createElement("div");
        Artist_Avatar_And_Name.className = "Artist-AvatarAndName";
        Artist_Avatar_And_Name.id = nft.creator.nickName;

        const Avatar_Image = document.createElement("img");
        Avatar_Image.src = nft.creator.imagePath;
        Avatar_Image.style.width = "25px";
        Avatar_Image.style.objectFit = "cover";

        const Artist_Name = document.createElement("p");
        Artist_Name.textContent = nft.creator.nickName;

        Artist_Avatar_And_Name.addEventListener("click", (event) => {
            event.stopPropagation();
            window.open(`../Artist_Detail?id=${nft.creatorId}`, "_self");
        });

        Artist_Avatar_And_Name.append(Avatar_Image, Artist_Name);

        Artist_Info.append(NFT_Name, Artist_Avatar_And_Name);

        const Additional_Info = document.createElement("div");
        Additional_Info.className = "Additional-Info";

        const Price = document.createElement("div");
        Price.className = "Price";

        const Price_Key = document.createElement("h1");
        Price_Key.textContent = "Price";

        const Price_Value = document.createElement("p");
        Price_Value.textContent = nft.price

        Price.append(Price_Key, Price_Value);

        const HighestBid = document.createElement("div");
        HighestBid.className = "Highest-Bid";

        const Bid_Key = document.createElement("h1");
        Bid_Key.textContent = "Highest Bid";

        const Bid_Value = document.createElement("p");
        Bid_Value.textContent = nft.highestBid

        HighestBid.append(Bid_Key, Bid_Value);

        Additional_Info.append(Price, HighestBid);

        NFT_Info.append(Artist_Info, Additional_Info);

        NFT_Card.append(Image, NFT_Info);

        NFTCards_Row.append(NFT_Card);

        NFT_Card.addEventListener("click", () => {
            window.open(`../Nft_Detail?id=${nft.id}`, "_self");
        });
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
window.addEventListener("DOMContentLoaded", getDataForNfts);