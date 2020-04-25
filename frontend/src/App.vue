<template>
  <main>
    <TheHeader :color="settings.color" :text="settings.text" :sitetitle="sitetitle"></TheHeader>
    <router-view></router-view>
    <TheFooter :text="settings.color" :color="settings.text" :sitetitle="sitetitle"></TheFooter>
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
      settings: {},
      sitetitle: "Oslo Burger"
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

body {
  background-color: rgb(29, 29, 31);
  color: white;
}

h1,
h2,
h3,
h4,
h5,
a {
  font-family: var(--heading);
}

a {
  color: rgb(0, 162, 255);
  text-decoration: none;
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
  background: black;
  color: white;
}

a,
button,
input[type="file"],
input[type="color"] {
  cursor: pointer;
}

button {
  padding: 7px 20px;
  font-size: 1em;
  border: none;
  border-radius: 0;
  outline: none;
  background: white;
  color: black;
  font-weight: 700;
  font-family: var(--heading);
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="color"],
input[type="file"],
select,
textarea,
label.input {
  width: 100%;
  padding: 5px 3px;
  margin-top: 3px;
  font-size: 1em;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="color"],
select {
  border: none;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
select,
textarea,
label.input {
  background: rgba(255, 255, 255, 1);
  color: black;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
select {
  border-bottom: 1px solid rgba(0, 0, 0, 0.4);
}

input[type="file"],
input[type="color"] {
  z-index: 1;
}

input[type="color"] {
  padding: 0;
  margin: 0;
  height: 35px;
  background: transparent;
}

input,
select {
  border-radius: 0;
}

label {
  font-size: 0.9em;
}

label.hint {
  margin: 2px 0 0 2px;
  font-size: 0.8em;
}

textarea {
  min-height: 50px;
  resize: vertical;
}

select[multiple] {
  border: 1px solid black;
  padding: 0;
  height: 100px;
  overflow: auto;
}

option {
  padding: 5px 2px;
  border-bottom: 1px solid rgba(0, 0, 0, 0.2);
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
  left: 0;
  top: 0;
}

.card {
  position: relative;
  z-index: 1;
  transition: 0.2s ease-in-out;
  color: white;
}

.card::before {
  filter: blur(10px);
  content: "";
  position: absolute;
  left: -10px;
  top: -10px;
  width: calc(100% + 20px);
  height: calc(100% + 20px);
  z-index: -1;
}

.card::after {
  content: "";
  position: absolute;
  left: 0;
  top: 0;
  right: 0;
  bottom: 0;
  z-index: -1;
  background: rgb(65, 61, 61);
}

.card:hover {
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.05), 0 1px 8px rgba(0, 0, 0, 0.1);
}

.shadow {
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.05), 0 1px 8px rgba(0, 0, 0, 0.1);
}

footer {
  background: rgb(15, 15, 15);
}

@media screen and (prefers-color-scheme: light) {
  body {
    background-color: white;
    color: black;
  }

  a {
    color: rgb(0, 68, 255);
  }

  img {
    max-width: 100%;
    background: #bbbbbb;
    color: black;
  }

  button {
    background: black;
    color: white;
  }

  .card {
    color: black;
  }

  .card::after {
    background: #f0f0f0;
  }

  footer {
    background: rgb(241, 241, 241);
  }
}
</style>