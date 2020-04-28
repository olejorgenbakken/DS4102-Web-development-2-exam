<template>
  <section class="color-pickers">
    <ColorPicker v-model="colors.logo" class="color" :text="'Logo'" :value="colors.logo"></ColorPicker>
    <ColorPicker
      v-model="colors.highlighted"
      class="color"
      :text="'Fremhevet rett'"
      :value="colors.highlighted"
    ></ColorPicker>
    <ColorPicker
      v-model="colors.highlightedText"
      class="color"
      :text="'Fremhevet tekst'"
      :value="colors.highlightedText"
    ></ColorPicker>
  </section>
</template>

<script>
import axios from "axios";
import ColorPicker from "./ColorPickerItem";

export default {
  name: "Settings",
  components: {
    ColorPicker
  },
  data() {
    return {
      colors: null
    };
  },
  created() {
    let settingsURL = `https://localhost:5001/settings/1`;
    axios.get(settingsURL).then(response => {
      this.colors = response.data;
    });
  },
  updated() {
    const settingsURL = `https://localhost:5001/settings`;
    axios.put(settingsURL, this.colors);
  }
};
</script>

<style scoped>
.color-pickers {
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
}

@media only screen and (min-width: 400px) {
  .color-pickers {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media only screen and (min-width: 700px) {
  .color-pickers {
    grid-template-columns: repeat(3, 1fr);
  }
}
</style>