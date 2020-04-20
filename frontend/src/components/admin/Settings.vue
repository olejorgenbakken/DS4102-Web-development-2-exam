<template>
  <section class="settings">
    <ColorPicker
      v-model="settings.color"
      class="color card"
      :text="'Fremhevet farge'"
      :value="settings.color"
    ></ColorPicker>
    <ColorPicker
      v-model="settings.text"
      class="text card"
      :text="'Tekstfarge'"
      :value="settings.text"
    ></ColorPicker>
    <DishTypes :text="'Lag ny kategori'" v-model="settings.dishTypes" :value="newType"></DishTypes>
  </section>
</template>

<script>
import axios from "axios";
import ColorPicker from "./SettingsAssets/ColorPicker";
import DishTypes from "./SettingsAssets/DishTypes";

export default {
  name: "Settings",
  components: {
    ColorPicker,
    DishTypes
  },
  data() {
    return {
      newType: "",
      settings: {}
    };
  },
  created() {
    const settingsURL = `https://localhost:5001/settings/1`;
    axios.get(settingsURL).then(response => {
      this.settings = response.data;
    });
  },
  updated() {
    const settingsURL = `https://localhost:5001/settings`;
    axios.get(settingsURL).then(response => {
      console.log(response.data);
    });
    axios.put(settingsURL, this.settings);
  }
};
</script>

<style scoped>
.settings {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 40px;
}
</style>