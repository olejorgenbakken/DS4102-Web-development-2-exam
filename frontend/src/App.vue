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
button,
input[type="file"],
input[type="color"] {
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
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
select {
  border-bottom: 1px solid rgba(0, 0, 0, 0.8);
}

input[type="file"],
input[type="color"] {
  z-index: 1;
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
}

.card {
  position: relative;
  overflow: hidden;
  z-index: 1;
  transition: 0.2s ease-in-out;
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
  background: #f0f0f0;
}

.card:hover {
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1), 0 1px 8px rgba(0, 0, 0, 0.2);
}

.card:hover::after {
  border: 1px solid #fff;
}

.submit-btn {
  background: black;
  color: white;
}
</style>