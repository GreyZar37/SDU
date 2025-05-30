const dropdownButtons = document.querySelectorAll('.dropbtn');
const lessonsContent = document.querySelectorAll('.lessons-content-show, .lessons-content');

dropdownButtons.forEach(button => {
  button.addEventListener('click', function (event) {
    // Close other open dropdowns
    const allDropdowns = document.querySelectorAll('.dropdown-content');
    allDropdowns.forEach(dropdown => {
      if (dropdown !== this.nextElementSibling) {
        dropdown.classList.remove('show');  
      }
    });

    // Toggle the current dropdown
    const dropdownContent = this.nextElementSibling;
    dropdownContent.classList.toggle('show');  

    event.stopPropagation(); 
  });
});


function changeContent(pageName) {
  lessonsContent.forEach(content => content.style.display = 'none');
  const targetContent = document.getElementById(pageName);
  if (targetContent) {
      targetContent.style.display = 'block';
  } else {
      console.error(`Content with ID "${pageName}" not found.`);
  }
}


let currentPageIndex = 0;
const lessonsContentArray = Array.from(lessonsContent);

function nextPage() {
   print("nextPage");
    lessonsContentArray[currentPageIndex].style.display = 'none';
    currentPageIndex++;
    if (currentPageIndex >= lessonsContentArray.length) {
        currentPageIndex = currentPageIndex -1;
    }
    lessonsContentArray[currentPageIndex].style.display = 'block';
}

function previousPage() {
    print("previousPage");
    lessonsContentArray[currentPageIndex].style.display = 'none';
    currentPageIndex--;
    if (currentPageIndex < 0) {
        currentPageIndex = 0;
    }
    lessonsContentArray[currentPageIndex].style.display = 'block';
}




// Component Search Functionality


const componentsDatabase = [
  {
      type: "Cpu Cooler",
      name: "Cooler Master Hyper 212",
      manufacturer: "Cooler Master",
      price: 50,
      link: "",
      image: ""
  },
  {
      type: "RAM",
      name: "Corsair Vengeance 16GB DDR4",
      manufacturer: "Corsair",
      price: 80,
     link: "",
      image: ""
  },
  {
      type: "Case",
      name: "NZXT H510",
      manufacturer: "NZXT",
      price: 70,
      link: "",
      image: ""
  },
  {
      type: "GPU",
      name: "NVIDIA RTX 3060",
      manufacturer: "NVIDIA",
      price: 400,
      link: "",
      image: ""
  },
  {
      type: "PSU",
      name: "EVGA 750W Gold",
      manufacturer: "EVGA",
      price: 120,
    link: "",
      image: ""
  },
  {
      type: "Storage",
      name: "Samsung 970 EVO 1TB SSD",
      manufacturer: "Samsung",
      price: 100,
     link: "",
      image: ""
  },
  {
      type: "Motherboard",
      name: "ASUS ROG Strix B550-F",
      manufacturer: "ASUS",
      price: 200,
      link: "",
      image: ""
  },
  {
    type: "CPU",
      name: "Intel Core i9-14900K Raptor Lake-S CPU - 24 kerner - 3.2 GHz - Intel LGA1700 - Intel Boxed (uden køler)",
      manufacturer: "Intel",
      price: 3444.00,
      link: "https://www.proshop.dk/CPU/Intel-Core-i9-14900K-Raptor-Lake-S-CPU-24-kerner-32-GHz-Intel-LGA1700-Intel-Boxed-uden-koeler/3195721",
      image: "https://www.proshop.dk/Images/300x251/3195721_872d9c47a449.png"
  },
  {
    type: "CPU",
      name: "AMD Ryzen 7 9800X3D CPU - 8 kerner - 4.7 GHz - AMD AM5 - AMD Boxed (uden køler)",
      manufacturer: "AMD",
      price: 4190.00,
      link: "https://www.proshop.dk/CPU/AMD-Ryzen-7-9800X3D-CPU-8-kerner-47-GHz-AMD-AM5-AMD-Boxed-uden-koeler/3310690",
      image: "https://www.proshop.dk/Images/300x251/3310690_dfea0e4e20c0.png"
  }
];


function filterComponents() {
  const type = document.getElementById("componentType").value;
  const manufacturer = document.getElementById("manufacturer").value.toLowerCase();
  const minPrice = parseFloat(document.getElementById("minPrice").value) || 0;
  const maxPrice = parseFloat(document.getElementById("maxPrice").value) || Infinity;

  const filteredComponents = componentsDatabase.filter(component =>
      (type === "" || component.type === type) &&
      (manufacturer === "" || component.manufacturer.toLowerCase().includes(manufacturer)) &&
      component.price >= minPrice &&
      component.price <= maxPrice
  );

  displayResults(filteredComponents);
}

function displayResults(components) {
  const resultsList = document.getElementById("resultsList");
  resultsList.innerHTML = ""; 

  if (components.length === 0) {
    resultsList.innerHTML = "<li>No components found</li>";
    return;
  }


 components.forEach(component => {
    const listItem = document.createElement("li");
    listItem.style.display = "flex";
    listItem.style.alignItems = "center";
    listItem.style.gap = "10px";

    listItem.innerHTML = `
      <img src="${component.image}" alt="${component.name}" style="width: 100px; height: auto; border-radius: 4px;">
      <div id="component-item">
        <strong>${component.name}</strong> 
        (${component.type}) - ${component.price}kr.<br>
        Manufacturer: ${component.manufacturer}<br>
        <a href="${component.link}" target="_blank" style="">View Product</a>
        <button onclick="addToBuild('${component.type}', '${component.name}', '${component.image}')">Add to build</button>
      </div>`;
    resultsList.appendChild(listItem);
  });
}


function goToPage(page) {
  window.location.href = page;
}


function addToBuild(type, name, image) {
  const selectedComponents = JSON.parse(localStorage.getItem("selectedComponents")) || {};
  selectedComponents[type] = { name, image };
  localStorage.setItem("selectedComponents", JSON.stringify(selectedComponents));

  window.location.href = "BuildPage.html";
}
document.addEventListener("DOMContentLoaded", () => {
  const selectedComponents = JSON.parse(localStorage.getItem("selectedComponents")) || {};

  for (const [type, component] of Object.entries(selectedComponents)) {
    const slotId = `${type.replace(/\s+/g, '')}-slot`;
    const slot = document.getElementById(slotId);

    if (slot) {
      const addedComponentDiv = slot.querySelector("#added-component");
      addedComponentDiv.innerHTML = `
        <div style="display: flex; align-items: center; gap: 10px;">
          <img src="${component.image}" alt="${component.name}" style="width: 80px; height: auto; border-radius: 4px;">
          <span>${component.name}</span>
          <button onclick="removeFromBuild('${type}')">Remove</button>
        </div>`;
    }
  }
});

function removeFromBuild(type) {
  const selectedComponents = JSON.parse(localStorage.getItem("selectedComponents")) || {};

  delete selectedComponents[type];

  localStorage.setItem("selectedComponents", JSON.stringify(selectedComponents));

  window.location.href = "BuildPage.html";
}

document.getElementById("searchButton").addEventListener("click", filterComponents);

function goToComponentFilter(componentType) {
  localStorage.setItem("selectedFilterType", componentType);

  window.location.href = "ComponentsPage.html";
}

document.getElementById("CPU-slot-button").addEventListener("click", () => goToComponentFilter("CPU"));
document.getElementById("GPU-slot-button").addEventListener("click", () => goToComponentFilter("GPU"));
document.getElementById("RAM-slot-button").addEventListener("click", () => goToComponentFilter("RAM"));
document.getElementById("Motherboard-slot-button").addEventListener("click", () => goToComponentFilter("Motherboard"));
document.getElementById("Storage-slot-button").addEventListener("click", () => goToComponentFilter("Storage"));
document.getElementById("PSU-slot-button").addEventListener("click", () => goToComponentFilter("PSU"));
document.getElementById("Case-slot-button").addEventListener("click", () => goToComponentFilter("Case"));
document.getElementById("CpuCooler-slot-button").addEventListener("click", () => goToComponentFilter("Cpu Cooler"));

document.addEventListener("DOMContentLoaded", () => {
  const selectedFilterType = localStorage.getItem("selectedFilterType");

  if (selectedFilterType) {
    const componentTypeDropdown = document.getElementById("componentType");
    componentTypeDropdown.value = selectedFilterType;

    localStorage.removeItem("selectedFilterType");

    filterComponents();
  }
});


