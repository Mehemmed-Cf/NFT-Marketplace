let searchParams = new URLSearchParams(window.location.search);
let paramsNftId = searchParams.get("id");
const loaderElement = document.querySelector(".Loader");

getDataForNfts();

function getDataForNfts() {
    showLoader(true);

    fetch(`/Nft_Detail/GetNft?Id=${paramsNftId}`)
        .then(res => {
            if (!res.ok) {
                console.error(`HTTP error! status: ${res.status}`);
                if (res.status >= 400 && res.status < 600) {
                    //window.location.href = "/NotFound";
                    return;
                }
                throw new Error(`HTTP error! status: ${res.status}`);
            }
            return res.json();
        })
        .then(responseData => {
            showLoader(false);

            console.log('Fetched Data:', responseData);

            //if (nft.redirectUrl) {
            //    console.log('Redirecting because of redirectUrl:', nft.redirectUrl);
            //    window.location.href = nft.redirectUrl;
            //    return;
            //}

            const { nft, creator } = responseData;

            if (responseData.error) { //nft
                console.log('Redirecting because of error:', nft.error);
                //window.location.href = "/NotFound";
                return;
            }

            fillNftInfo(nft, creator);

            if (Array.isArray(responseData.othernfts) && responseData.othernfts.length > 0) {
                fillOtherNfts(responseData.othernfts);
            } else {
                console.log('No NFTs found for this creator.');
            }

            //if (Array.isArray(nft.nfts) && nft.nfts.length > 0) {
            //    fillOtherNfts(nft);
            //} else {
            //    console.log('No NFTs found for this creator.');
            //}
        })
        .catch(error => {
            console.error('Fetch error:', error);
            showLoader(false);
            //window.location.href = "/NotFound";
        });
}

function fillNftInfo(nft, creator) {
    fillBigNft(nft);
    fillNftHeadlineAndSubhead(nft);
    fillAdditionalInfo(nft, creator);
    goToArtist(creator);
    fillOtherNfts(nft, creator);
}

function fillBigNft(nft) {
    const NFT_Detail_Section = document.querySelector("#NFT-Detail_Section");
    NFT_Detail_Section.style.backgroundColor = "#2b2b2b";

    const bigNftImage = document.createElement("img");
    bigNftImage.src = nft.imagePath;
    bigNftImage.Id = "NFT_Image";
    //bigNftImage.style.backgroundColor = "#3b3b3b";
    bigNftImage.style.width = "45%";
    bigNftImage.style.height = "auto";
    bigNftImage.style.objectFit = "cover";

    NFT_Detail_Section.prepend(bigNftImage);
}

function fillNftHeadlineAndSubhead(nft) {
    const Nft_HeadlineAndSubhead = document.querySelector(".Nft-HeadlineAndSubhead");

    const Nft_Name = document.createElement("p");
    Nft_Name.textContent = nft.title;
    Nft_Name.className = "Nft-Name";

    //Minted Date preparing

    const dateStr = nft.mintedAt
    const date = new Date(dateStr);

    const options = { year: 'numeric', month: 'short', day: 'numeric' };
    const formatted = date.toLocaleDateString('en-US', options);

    //Minted Date preparing finished

    const Nft_Minted = document.createElement("p");
    Nft_Minted.textContent = "Minted On" + " " + formatted //"Minted on Sep 30, 2022";
    Nft_Minted.className = "Nft-Minted";

    Nft_HeadlineAndSubhead.append(Nft_Name, Nft_Minted);
}

function fillAdditionalInfo(nft, creator) {
    const Artist_Card = document.querySelector(".Artist-Card");
    const Nft_Description = document.querySelector("#Description");

    Artist_Card.style.transition = "transform 0.5s ease"

    Artist_Card.addEventListener("mouseenter", () => {
        Artist_Card.style.transform = "scale(1.05)";
        Artist_Card.style.boxShadow = "0 10px 20px rgba(0,0,0,0.2)";
    });

    Artist_Card.addEventListener("mouseleave", () => {
        Artist_Card.style.transform = "scale(1)";
        Artist_Card.style.boxShadow = "none";
    });

    Artist_Card.addEventListener("click", () => {
        window.open(`../Artist_Detail?id=${creator.id}`, "_self");
    });

    const ProfileIcon = document.createElement("img");
    ProfileIcon.style.width = "25px";

    ProfileIcon.src = creator.imagePath;

    const Artist_Name = document.createElement("p");
    Artist_Name.textContent = creator.nickName;

    const description = document.createElement("p");
    //const tempDiv = document.createElement("div");
    //tempDiv.innerHTML = nft.description;
    description.style.color = "#ffffff";
    description.style.backgroundColor = "transparent";
    description.innerHTML = nft.description
        .replace(/<\/p>/gi, "<br><br>")
        .replace(/<p[^>]*>/gi, "");  
    //description.textContent = tempDiv.textContent || tempDiv.innerText || "";

    Artist_Card.append(ProfileIcon, Artist_Name);
    Nft_Description.append(description);
}

function goToArtist(creator) {
    const GoToArtistbtn = document.querySelector("#GoToArtist");

    GoToArtistbtn.addEventListener("click", () => {
        window.open(`../Artist_Detail?id=${creator.id}`, "_self");
    });
}

function fillOtherNfts(nft, creator) {
    const NFT_Cards_Section = document.querySelector(".NFT-Cards_Section");
    const NoNftMessage = document.querySelector("#NoNFT_Message");

    console.log('Fetched othernfts from the creator:', nft.othernfts);

    if (!nft.othernfts || nft.othernfts.length === 0) {
        NoNftMessage.style.display = "block";
    } else {
        NoNftMessage.style.display = "none";
        nft.othernfts.forEach((nft) => {

            const NFT_Card = document.createElement("div");
            NFT_Card.className = "NFTCard";
            //NFT_Card.className = "NFT-Card";

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

            const Artist_Avatar = document.createElement("div");
            Artist_Avatar.className = "Avatar";

            const Avatar_Image = document.createElement("img");
            Avatar_Image.src = creator.imagePath;

            Artist_Avatar.append(Avatar_Image);

            const Artist_Name = document.createElement("h1");
            Artist_Name.textContent = creator.nickName;

            Artist_Avatar_And_Name.append(Artist_Avatar, Artist_Name);

            Artist_Info.append(NFT_Name, Artist_Avatar_And_Name);

            const Additional_Info = document.createElement("div");
            Additional_Info.className = "Additional-Info";

            const Price = document.createElement("div");
            Price.className = "Price";

            const Price_Key = document.createElement("h1");
            Price_Key.textContent = "Price";

            const Price_Value = document.createElement("p");
            Price_Value.textContent = `${nft.price} ETH`;

            Price.append(Price_Key, Price_Value);

            const HighestBid = document.createElement("div");
            HighestBid.className = "Highest-Bid";

            const Bid_Key = document.createElement("h1");
            Bid_Key.textContent = "Highest Bid";

            const Bid_Value = document.createElement("p");
            Bid_Value.textContent = `${nft.highestBid} wETH`;

            HighestBid.append(Bid_Key, Bid_Value);

            Additional_Info.append(Price, HighestBid);

            NFT_Info.append(Artist_Info, Additional_Info);

            NFT_Card.append(Image, NFT_Info);

            NFT_Cards_Section.append(NFT_Card);

            NFT_Card.addEventListener("click", () => {
                window.open(`../Nft_Detail?id=${nft.id}`, "_self");
            });
        });
    }

}

function showLoader(show) {
    loaderElement.style.display = show ? "grid" : "none";
}