<template>
  <section class="color-pickers">
    <ColorPicker v-model="colors.highlighted" :text="'Fremhevet farge'" :value="colors.highlighted"></ColorPicker>
    <ColorPicker
      v-model="colors.highlightedText"
      :text="'Fremhevet tekst'"
      :value="colors.highlightedText"
    ></ColorPicker>
    <ColorPicker v-model="colors.logo" :text="'Logo'" :value="colors.logo"></ColorPicker>
  </section>
</template>

<script>
import { store } from "../../../store.js";
import ColorPicker from "./ColorPickerItem";

export default {
  name: "Settings",
  components: {
    ColorPicker
  },
  data() {
    return {
      colors: store.state.colors
    };
  },
  updated() {}
};
</script>

<style scoped>
.color-pickers {
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
}

@media only screen and (min-width: 800px) {
  .color-pickers {
    grid-template-columns: repeat(2, 1fr);
  }
}
</style>