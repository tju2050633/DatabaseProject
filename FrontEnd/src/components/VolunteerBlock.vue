<template>
    <div>
        <h2>
            <span style="flex: 1; text-align: left;"><el-icon style="margin-top: 10px"><user />
            </el-icon>{{ content.username }}</span>
        </h2>
        <h3>
            &ensp;&ensp;
            {{ content.gardenname }}
        </h3>
        <div style="text-align: center;">
            <img :src="content.imageUrl" alt="花园图片" style="width: 60%">
        </div>
        <h4>
            &ensp;&ensp;&ensp;
            地点：
            {{ content.location }}
        </h4>
        <p>
            &ensp;&ensp;&ensp;&ensp;&ensp;
            描述：
            {{ content.describe }}
        </p>
 
    </div>
</template>

<script>
export default {
    name: 'VolunteerBlock',
    props: {
        content: {
            type: Object,
            required: true
        }
    },
}
</script>
