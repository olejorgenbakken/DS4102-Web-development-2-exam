<template>
  <main>
    <TheHeader :color="settings.color" :text="settings.text"></TheHeader>
    <router-view></router-view>
    <TheFooter :text="settings.color" :color="settings.text"></TheFooter>
  </main>
</template>

<script>
import axios from "axios";
import TheHeader from "./components/TheHeader";
import TheFooter from "./components/TheFooter";

export default {
  name: "App",
  components: {
    TheHeader,
    TheFooter
  },
  data() {
    return {
      settings: {}
    };
  },
  created() {
    const settings = `https://localhost:5001/settings/1`;
    axios.get(settings).then(response => {
      this.color = response.data.color;
      this.text = response.data.text;
    });
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:500,700,900|Roboto:400&display=swap");
:root {
  --heading: "Montserrat", sans-serif;
  --paragraph: "Roboto", sans-serif;
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  scroll-behavior: smooth;
}

h1,
h2,
h3,
h4,
h5 {
  font-family: var(--heading);
}

h1 {
  font-weight: 900;
}

h2 {
  font-weight: 700;
}

p,
textarea,
label,
small {
  font-family: var(--paragraph);
}

small {
  font-weight: 400;
}

img {
  max-width: 100%;
}

a,
button {
  cursor: pointer;
}

a {
  color: inherit;
  text-decoration: none;
}

button {
  padding: 7px 20px;
  font-size: 1em;
  border: none;
  border-radius: 0;
  outline: none;
  background: transparent;
  font-family: var(--heading);
}

input,
select {
  border-radius: 0;
  background: transparent;
}

label {
  font-size: 0.9em;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
select {
  font-size: 1em;
  border: none;
  border-bottom: 1px solid rgba(0, 0, 0, 0.8);
  width: 100%;
  padding: 5px 10px;
  margin-top: 3px;
}

figure {
  overflow: hidden;
  position: relative;
}

figure img {
  position: absolute;
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.card {
  background: #fff;
}
</style>