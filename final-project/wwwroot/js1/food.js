let divs = document.querySelectorAll("form > div");
let nextbtn = document.getElementById("next");
let prevbtn = document.getElementById("previous");
let progreesSpan = document.querySelector(".inner-prog");
let buttonForm = document.querySelector("form button");
let count = 11;
prevbtn.disabled = true;
buttonForm.disabled = true;

nextbtn.addEventListener("click", function () {
  if (count === 11) {
    progreesSpan.style.width = 9.9 + "%";
  } else {
    progreesSpan.style.width = parseFloat(progreesSpan.style.width) + 9.9 + "%";
  }
  console.log(progreesSpan.style.width);
  divs[count].style.animationName = "firstnext";
  count--;
  divs[count].style.animationName = "secondnext";
  if (count === 0) {
    nextbtn.disabled = true;
    buttonForm.disabled = false;
  }
  if (count > 0) {
    prevbtn.disabled = false;
  }
});
prevbtn.addEventListener("click", function () {
  progreesSpan.style.width = parseFloat(progreesSpan.style.width) - 9.8 + "%";
  console.log(progreesSpan.style.width);
  divs[count].style.animationName = "firstprev";
  count++;
  divs[count].style.animationName = "secondprev";
  if (count < 11) {
    nextbtn.disabled = false;
  }
  if (count === 11) {
    prevbtn.disabled = true;
  }
});
