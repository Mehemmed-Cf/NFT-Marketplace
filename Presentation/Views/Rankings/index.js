const Ranking_Items = document.querySelector(".Ranking-Items");
const loaderElement = document.querySelector(".Loader");
const CreatorId = document.querySelector("#CreatorId");
const CreatorName = document.querySelector("#CreatorName");
const CreatorChange = document.querySelector(".Change-Header");
const CreatorNFTs_Sold = document.querySelector(".NFTs-Sold-Header");
const CreatorVolume = document.querySelector(".Volume-Header");

getDataForCreators();

function getDataForCreators() {
  showLoader(true);
  fetch(`http://localhost:3000/api/creators`, {
    method: "GET",
  })
    .then((res) => res.json())
    .then((creator) => {
      CreatorId.addEventListener("click", () => sortById(creator));
      CreatorName.addEventListener("click", () => sortByName(creator));
      CreatorChange.addEventListener("click", () => sortByChange(creator));
      CreatorNFTs_Sold.addEventListener("click", () => sortByNFTsSold(creator));
      CreatorVolume.addEventListener("click", () => sortByVolume(creator));
      fillItemRanking(creator);
    });

  showLoader(false);
}

function fillItemRanking(data) {
  if (!data) return;

  emptyRanking();

  data.forEach((creator) => addCreatorItem(creator));
}

function addCreatorItem(creator) {
  const Ranking_Item = document.createElement("div");
  Ranking_Item.className = "Ranking-Item";
  Ranking_Item.classList.add("Container");

  const RankAndArtist = document.createElement("div");
  RankAndArtist.className = "RankAndArtist";

  const Ranking_Number = document.createElement("div");
  Ranking_Number.className = "Ranking-Number";

  const Ranking_Number_Element = document.createElement("p");
  Ranking_Number_Element.textContent = creator.id;

  const Artist_Card = document.createElement("div");
  Artist_Card.className = "Artist-Card";

  const Artist_Avatar = document.createElement("div");
  Artist_Avatar.className = "Artist-Avatar";

  const Avatar = document.createElement("div");
  Avatar.className = "Avatar";

  const AvatarElement = document.createElement("img");
  AvatarElement.src = "~/Frontend/../" + creator.profileImgPath;

  const Artist_Info = document.createElement("div");
  Artist_Info.className = "Artist-Info";

  const Artist_Name = document.createElement("h1");
  Artist_Name.textContent = creator.name;

  Artist_Info.append(Artist_Name);

  Avatar.append(AvatarElement);

  Artist_Avatar.append(Avatar);

  Ranking_Number.append(Ranking_Number_Element);

  Artist_Card.append(Artist_Avatar, Artist_Info);

  const Stats = document.createElement("div");
  Stats.className = "Stats";

  const Change = document.createElement("div");
  Change.className = "Change";

  const ChangeElement = document.createElement("p");
  ChangeElement.textContent = "+" + creator.totalSale.value;

  Change.append(ChangeElement);

  const NFTs_Sold = document.createElement("div");
  NFTs_Sold.className = "NFTs-Sold";

  const NFts_Sold_Element = document.createElement("p");
  NFts_Sold_Element.textContent = creator.nftSold;

  NFTs_Sold.append(NFts_Sold_Element);

  const Volume = document.createElement("div");
  Volume.className = "Volume";

  const Volume_Element = document.createElement("p");
  Volume_Element.textContent = creator.volume;

  Volume.append(Volume_Element);

  Stats.append(Change, NFTs_Sold, Volume);

  RankAndArtist.append(Ranking_Number, Artist_Card, Stats);

  const Delete_Btn = document.createElement("img");
  Delete_Btn.src = "~/Frontend/assets/icons/TrashIcon.svg";
  Delete_Btn.className = "Delete-Btn";

  Ranking_Item.append(RankAndArtist, Delete_Btn);

  Ranking_Items.append(Ranking_Item);

  if (creator.id > 9) {
    Ranking_Number_Element.classList.add("position-left-change");
  }

  Artist_Card.addEventListener("click", () => {
    window.open(`../Artist-Detail/index.html?id=${creator.id}`, "_self");
  });

  Delete_Btn.addEventListener("click", () => {
    deleteCreatorItem(creator, Ranking_Item);
  });
}

function deleteCreatorItem(creator, Item) {
  if (
    confirm(
      `Are you sure you want to delete the creator with the id ${creator.id}`
    )
  ) {
    showLoader(true);
    fetch(`http://localhost:3000/api/creators/${creator.id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status >= 200 && response.status < 300) {
        Item.remove();
        Toastify({
          text: "You Just threw a big pile of effort into the trash! ;)",
          duration: 3000,
          newWindow: true,
          close: true,
          gravity: "top",
          position: "right",
          stopOnFocus: true,
          style: {
            background: "green",
          },
        }).showToast();
      }
    });
    showLoader(false);
  }
}

function sortById(creator) {
  creator.sort((a, b) => {
    const idA = a.id;
    const idB = b.id;

    return idA - idB;
  });
  fillItemRanking(creator);
}

function sortByName(creator) {
  creator.sort((a, b) => {
    const nameA = a.name.toLowerCase();
    const nameB = b.name.toLowerCase();

    if (nameA < nameB) {
      return -1;
    }
    if (nameA > nameB) {
      return 1;
    }
    return 0;
  });
  fillItemRanking(creator);
}

function sortByChange(creator) {
  creator.sort((a, b) => {
    const ChangeA = a.totalSale.value;
    const ChangeB = b.totalSale.value;

    return ChangeB - ChangeA;
  });
  fillItemRanking(creator);
}

function sortByNFTsSold(creator) {
  creator.sort((a, b) => {
    const NFTs_SoldA = a.nftSold;
    const NFTs_SoldB = b.nftSold;

    return NFTs_SoldB - NFTs_SoldA;
  });
  fillItemRanking(creator);
}

function sortByVolume(creator) {
  creator.sort((a, b) => {
    const VolumeA = a.volume;
    const VolumeB = b.volume;

    return VolumeB - VolumeA;
  });
  fillItemRanking(creator);
}

function emptyRanking() {
  while (Ranking_Items.firstChild) {
    Ranking_Items.removeChild(Ranking_Items.firstChild);
  }
}

function showLoader(show) {
  loaderElement.style.display = show ? "grid" : "none";
}
