<template>
  <article class="color-picker card">
    <h2 class="color-picker">
      <label class="label">
        Fremhevet farge
        <input type="color" :value="color" @input="sendData" />
      </label>
    </h2>
  </article>
</template>

<script>
import axios from "axios";
export default {
  name: "ColorPicker",
  data() {
    return {
      color: "#ffffff"
    };
  },
  created() {
    const settings = `https://localhost:5001/settings/1`;
    axios.get(settings).then(response => {
      this.color = response.data.color;
    });
  },
  methods: {
    sendData() {
      let settingsURL = `https://localhost:5001/settings/1`;
      axios.get(settingsURL).then(response => {
        let settings = response.data;
        settings.color = this.$el.querySelector("input").value;
        let allSettings = `https://localhost:5001/settings`;
        axios.put(allSettings, settings);
      });
    }
  }
};
</script>

<style scoped>
.color-picker {
  border-radius: 20px;
  display: flex;
  flex-direction: column;
}

input {
  height: 30px;
  width: 100%;
  border-radius: 20px;
  overflow: hidden;
  cursor: pointer;
}
</style>