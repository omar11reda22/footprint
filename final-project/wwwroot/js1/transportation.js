let divs = document.querySelectorAll("form > div");
let nextbtn = document.getElementById("next");
let prevbtn = document.getElementById("previous");
let progreesSpan = document.querySelector(".inner-prog");
let buttonForm = document.querySelector("form button");
buttonForm.disabled = true;
let count = 4;
prevbtn.disabled = true;
nextbtn.addEventListener("click", function () {
  if (count === 4) {
    progreesSpan.style.width = 25 + "%";
  } else {
    progreesSpan.style.width = parseFloat(progreesSpan.style.width) + 25 + "%";
  }
  divs[count].style.animationName = "firstnext";
  count--;
  divs[count].style.animationName = "secondnext";
  console.log(count);
  if (count === 0) {
    nextbtn.disabled = true;
    buttonForm.disabled = false;
  }
  if (count > 0) {
    prevbtn.disabled = false;
  }
});
prevbtn.addEventListener("click", function () {
  progreesSpan.style.width = parseFloat(progreesSpan.style.width) - 25 + "%";
  divs[count].style.animationName = "firstprev";
  count++;
  divs[count].style.animationName = "secondprev";
  console.log(count);
  if (count < 4) {
    nextbtn.disabled = false;
  }
  if (count === 4) {
    prevbtn.disabled = true;
  }
});
