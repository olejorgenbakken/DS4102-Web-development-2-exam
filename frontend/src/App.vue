<template>
  <v-app>
    <router-view></router-view>
  </v-app>
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
</style>