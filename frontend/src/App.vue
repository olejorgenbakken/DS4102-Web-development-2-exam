<template>
  <main>
    <TheHeader></TheHeader>
    <router-view></router-view>
    <TheFooter></TheFooter>
  </main>
</template>

<script>
import TheHeader from "./components/TheHeader";
import TheFooter from "./components/TheFooter";

export default {
  name: "App",
  components: {
    TheHeader,
    TheFooter
  }
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

.label {
  font-family: var(--heading);
  font-size: 0.6em;
  font-weight: 400;
}

h1,
h2,
h3,
h4,
h5,
button {
  font-family: var(--heading);
}

p,
input,
select,
textarea {
  font-family: var(--paragraph);
}

input,
select,
button {
  border: none;
  outline: none;
  background: #fff;
}

select {
  cursor: pointer;
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
  border-radius: 15px;
  padding: 20px;
  background: #ffffff;
  box-shadow: 5px 5px 30px #e0e0e0, -5px -5px 30px #ffffff;
}
</style>