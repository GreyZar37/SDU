// Select all dropdown buttons
const dropdownButtons = document.querySelectorAll('.dropbtn');

// Add click event listener for each dropdown button
dropdownButtons.forEach(button => {
  button.addEventListener('click', function (event) {
    // Close other open dropdowns
    const allDropdowns = document.querySelectorAll('.dropdown-content');
    allDropdowns.forEach(dropdown => {
      if (dropdown !== this.nextElementSibling) {
        dropdown.classList.remove('show'); // Close other dropdowns
      }
    });

    // Toggle the current dropdown
    const dropdownContent = this.nextElementSibling;
    dropdownContent.classList.toggle('show'); // Add/remove "show" class

    event.stopPropagation(); // Stop click from propagating to document
  });
});

// Close dropdowns when clicking outside
document.addEventListener('click', function () {
  const allDropdowns = document.querySelectorAll('.dropdown-content');
  allDropdowns.forEach(dropdown => {
    dropdown.classList.remove('show'); // Remove "show" class to close dropdown
  });
});

// Close dropdowns when pressing the Escape key
document.addEventListener('keydown', function (event) {
  if (event.key === 'Escape') {
    const allDropdowns = document.querySelectorAll('.dropdown-content');
    allDropdowns.forEach(dropdown => {
      dropdown.classList.remove('show'); // Remove "show" class
    });
  }
});
