<template>
  <main>
    <router-view></router-view>
  </main>
</template>

<script>
export default {
  name: "App"
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:500,700,900|Roboto:400&display=swap");
:root {
  --black: #111;
  --heading: "Montserrat", sans-serif;
  --paragraph: "Roboto", sans-serif;
  --color: #133e66;
  --button: rgb(255, 255, 255);
}
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  scroll-behavior: smooth;
}

img {
  max-width: 100%;
}

a {
  text-decoration: none;
  color: inherit;
}

h1,
h2,
h3,
h4,
h5,
button {
  font-family: var(--heading);
}

p {
  font-family: var(--paragraph);
}

label {
  font-family: var(--heading);
  font-weight: 500;
  font-size: 0.8em;
}

.padding {
  padding: 0 20px;
}

.card {
  background: #ffffff;
  box-shadow: 9px 9px 18px #ebebeb, -9px -9px 18px #ffffff;
  transition: 0.2s ease-in-out;
}

.card:hover {
  box-shadow: 9px 9px 18px #d6d6d6, -9px -9px 18px #ffffff;
}
</style>