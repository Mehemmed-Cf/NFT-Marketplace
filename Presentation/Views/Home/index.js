const Rankings = document.querySelector("#Rankings");
const ConnectAWallet = document.querySelector("#ConnectAWallet");
const loaderElement = document.querySelector(".Loader");

const GetStarted_Btn = document.querySelector(".GetStarted-Btn");
GetStarted_Btn.addEventListener("click", () => {
  window.open("../CreateAccount/index.cshtml", "_self");
});

const HomeNFT = document.querySelector(".HighlightedNFT-Img");
HomeNFT.addEventListener("click", () => {
  window.open("Marketplace", "_self");
});


const HomeNFT = document.querySelector(".HighlightedNFT-Img");
HomeNFT.addEventListener("click", () => {
    window.open("Marketplace", "_self");
});

const CollectionCards = document.querySelectorAll(".CollectionCard");
CollectionCards.forEach((CollectionCard) => {
  CollectionCard.addEventListener("click", () => {
    window.open("Marketplace", "_self");
  });
});

const MrFox = document.querySelector("#MrFox");
const BeKind2Robots = document.querySelector("#BeKind2Robots");

MrFox.addEventListener("click", (e) => {
  e.stopPropagation();
  window.open("../Artist-Detail/index.html?id=6", "_self");
});

BeKind2Robots.addEventListener("click", (e) => {
  e.stopPropagation();
  window.open("../Artist-Detail/index.html?id=8", "_self");
});

const ViewRankings_Btn = document.querySelector(".ViewRankings-Btn");
ViewRankings_Btn.addEventListener("click", () => {
  window.open("Rankings", "_self");
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
    window.open("../Marketplace/index.html", "_self");
  });
});

const MoonDancer = document.querySelector("#MoonDancer");
MoonDancer.addEventListener("click", (e) => {
  e.stopPropagation();
  window.open("../Artist-Detail/index.html?id=10", "_self");
});

const NebulaKid = document.querySelector("#NebulaKid");
NebulaKid.addEventListener("click", (e) => {
  e.stopPropagation();
  window.open("../Artist-Detail/index.html?id=10", "_self");
});

const Spaceone = document.querySelector("#Spaceone");
Spaceone.addEventListener("click", (e) => {
  e.stopPropagation();
  window.open("../Artist-Detail/index.html?id=10", "_self");
});

const Shroomies = document.querySelectorAll("#Shroomie");
Shroomies.forEach((Shroomie) => {
  Shroomie.addEventListener("click", (e) => {
    e.stopPropagation();
    window.open(`../Artist-Detail/index.html?id=7`, "_self");
  });
});

const SeeNFT_Btn = document.querySelector(".SeeNFT-Btn");
SeeNFT_Btn.addEventListener("click", () => {
  window.open("../Marketplace/index.html", "_self");
});

getDataFromServer();

function getDataFromServer() {
  showLoader(true);
  fetch("http://localhost:3000/api/creators", {
    method: "GET",
  })
    .then((res) => res.json())
    .then((data) => fillArtistContainer(data));

  showLoader(false);
}

function fillArtistContainer(data) {
  if (!data) return;

  data.forEach((creator) => addCreator(creator));
}

function addCreator(data) {
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
  AvatarIcon.src = "~/Frontend/../" + data.profileImgPath;
  Artist_Avatar.append(AvatarIcon);

  const CreatorName = document.createElement("h1");
  CreatorName.textContent = data.name;

  const Sales_Info = document.createElement("div");
  Sales_Info.className = "Sales-Info";
  const Sales_Info_Key = document.createElement("p");
  Sales_Info_Key.className = "Sales-Info_Key";
  Sales_Info_Key.textContent = "Total Sales:";
  const Sales_Info_Value = document.createElement("p");
  Sales_Info_Value.className = "Sales-Info_Value";
  Sales_Info_Value.textContent = `${data.totalSale.value} ${data.totalSale.currency}`;
  Sales_Info.append(Sales_Info_Key, Sales_Info_Value);

  Artist_Info.append(CreatorName, Sales_Info);

  if (data.id > 9) {
    const RankingNumber = document.createElement("p");
    RankingNumber.textContent = data.id;
    RankingNumber.className = "position-left-change";
    Artist_Ranking.append(RankingNumber);
  } else {
    const RankingNumber = document.createElement("p");
    RankingNumber.textContent = data.id;
    Artist_Ranking.append(RankingNumber);
  }

  ArtistCard.append(Artist_Avatar, Artist_Info, Artist_Ranking);
  Artist_Cards.append(ArtistCard);

  ArtistCard.addEventListener("click", () => {
    window.open(`../Artist-Detail/index.html?id=${data.id}`, "_self");
  });
}

function showLoader(show) {
  loaderElement.style.display = show ? "grid" : "none";
}
