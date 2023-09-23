<script setup lang="ts">
import { ref } from 'vue'
import EditInput from './EditUtils/EditInput.vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditTextArea from './EditUtils/EditTextArea.vue';

const sectionHeader = ref("");
const sectionBody = ref("");

</script>

<template>
    <EditContainer :label="sectionHeader" type="Post Section">
        <EditInput label="Section Header" v-model="sectionHeader" />
        <EditTextArea label="Section Body" v-model="sectionBody" />
    </EditContainer>
</template>