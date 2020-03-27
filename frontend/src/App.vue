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
@import url("https://fonts.googleapis.com/css?family=Cinzel+Decorative:400,700,900|Montserrat:400,700&display=swap");
:root {
  --black: #111;
  --heading: "Cinzel Decorative", cursive;
  --subheading: "Montserrat", sans-serif;
  --color: rgb(238, 238, 238);
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
h2 {
  font-family: var(--heading);
}

label {
  font-family: var(--subheading);
  font-weight: 700;
  font-size: 0.8em;
}
</style>